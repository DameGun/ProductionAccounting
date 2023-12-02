import { NavLink, redirect, useLoaderData } from "react-router-dom";
import { createApplication } from "../utils/api";
import { Alert, Button, Label, TextInput } from "flowbite-react";
import { useEffect, useState } from "react";
import { DatePicker } from "../components/DatePicker";

export default function CreateApplicationPage() {
  const { data } = useLoaderData();
  const [inputFields, setInputFields] = useState({
    productId: null,
    packagesInBox: null,
    boxesInPallet: null,
    prodDate: Date,
    expDate: Date,
    currentApplicationState: 0,
  });
  const [errors, setErrors] = useState({});
  const [submitting, setSubmitting] = useState(false);
  const [responseStatus, setResponseStatus] = useState(false);

  const validateValues = (inputValues) => {
    let errors = {};
    console.log(inputValues);
    if (inputValues.productId === null) {
      errors.productId = "Must choose one value";
    }
    if (inputValues.packagesInBox <= 0) {
      errors.packagesInBox = "Number of packages can't be less then 1";
    }
    if (inputValues.boxesInPallet <= 0) {
      errors.boxesInPallet = "Number of boxes can't be less then 1";
    }
    if (inputValues.expDate === "") {
      errors.expDate = "Must choose production date";
    }
    if (inputFields.prodDate === "") {
      errors.prodDate = "Must choose expire date";
    }
    if (
      inputValues.expDate < inputValues.prodDate ||
      inputValues.expDate === inputValues.prodDate
    ) {
      errors.expDate = "Wrong date range";
    }

    return errors;
  };

  const handleChange = (e) => {
    setInputFields({ ...inputFields, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setErrors(validateValues(inputFields));
    setSubmitting(true);
  };

  const finishSubmit = async () => {
    setInputFields({
      ...inputFields,
      prodDate: inputFields.prodDate.toISOString(),
      expDate: inputFields.expDate.toISOString(),
    });
    await createApplication(inputFields);
  };

  useEffect(() => {
    if (Object.keys(errors).length === 0 && submitting) {
      finishSubmit();
      setResponseStatus(true);
    }
  }, [errors]);

  return (
    <div class="max-w-sm mx-auto mt-10">
      <div class="mb-5">
        <div className="mb-2">
          <Label htmlFor="productId" value="Choose product" />
        </div>
        <select
          id="productId"
          name="productId"
          defaultValue="Choose product"
          class={`${
            errors.productId &&
            "border-red-500 dark:border-red-600 focus:ring-2 focus:ring-red-500 dark:focus:ring-2 dark:focus:ring-red-600"
          } bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 `}
          onChange={handleChange}
        >
          {data.map((product) => {
            return (
              <option key={product.id} value={product.id}>
                {product.name}
              </option>
            );
          })}
        </select>
        <p className="mt-2 text-sm font-medium text-red-600 dark:text-red-500">
          {errors.productId}
        </p>
      </div>
      <div class="grid grid-cols-2 gap-6">
        <div class="mb-5">
          <div className="mb-2">
            <Label htmlFor="packagesInBox" value="Number of packages in box" />
          </div>
          <TextInput
            type="number"
            id="packagesInBox"
            name="packagesInBox"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
            color={errors.packagesInBox && "failure"}
            helperText={
              errors.packagesInBox && (
                <span className="font-medium">{errors.packagesInBox}</span>
              )
            }
            onChange={handleChange}
          />
        </div>
        <div class="mb-5">
          <div className="mb-2">
            <Label htmlFor="boxesInPallet" value="Number of boxes in pallet" />
          </div>
          <TextInput
            type="number"
            id="boxesInPallet"
            name="boxesInPallet"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
            color={errors.boxesInPallet && "failure"}
            helperText={
              errors.boxesInPallet && (
                <span className="font-medium">{errors.boxesInPallet}</span>
              )
            }
            onChange={handleChange}
          />
        </div>
      </div>
      <div class="grid grid-cols-2 gap-6">
        <div class="mb-5">
          <div className="mb-2">
            <Label htmlFor="prodDate" value="Production date" />
          </div>
          <DatePicker
            handleChange={handleChange}
            name="prodDate"
            error={errors.prodDate}
          />
        </div>
        <div class="mb-5">
          <div className="mb-2">
            <Label htmlFor="expDate" value="Expire date" />
          </div>
          <DatePicker
            handleChange={handleChange}
            name="expDate"
            error={errors.expDate}
          />
        </div>
      </div>
      {responseStatus && (
        <Alert className="mb-5">
          Production application was successfully created! Go to{" "}
          <NavLink
            className="underline"
            to="/applications?PageNumber=1&PageSize=2"
          >
            applications
          </NavLink>
        </Alert>
      )}
      <Button type="submit" size="sm" onClick={handleSubmit}>
        Submit
      </Button>
    </div>
  );
}
