import { useState, useEffect } from "react";
import { getCategories } from "../../utils/api";
import { Button, Label, TextInput } from "flowbite-react";

export default function ProductForm({
  apiCall,
  setResponseStatus,
  currentProduct,
}) {
  const [inputFields, setInputFields] = useState({
    name: "",
    weight: null,
    categoryId: null,
    cost: null,
  });
  const [errors, setErrors] = useState({});
  const [submitting, setSubmitting] = useState(false);
  const [categoriesData, setCategoriesData] = useState();

  useEffect(() => {
    const fetchData = async () => {
      const response = await getCategories(1, 1000);
      setCategoriesData(response.data);
    };

    fetchData().catch(console.error);

    if (currentProduct) setInputFields(currentProduct);
  }, []);

  useEffect(() => {
    if (Object.keys(errors).length === 0 && submitting) {
      finishSubmit();
      setResponseStatus(true);
    }
  }, [errors]);

  const validateValues = (inputValues) => {
    let errors = {};

    if (inputValues.categoryId === null) {
      errors.categoryId = "Must choose one value";
    }
    if (inputValues.weight <= 0) {
      errors.weight = "Weight can't be less then 1";
    }
    if (inputValues.cost <= 0) {
      errors.cost = "Cost can't be less then 1";
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
    console.log(inputFields);
    await apiCall(inputFields);
  };

  return (
    categoriesData && (
      <>
        <div class="mb-5">
          <div className="mb-2">
            <Label htmlFor="categoryId" value="Choose category" />
          </div>
          <select
            id="categoryId"
            name="categoryId"
            defaultValue={inputFields.categoryId}
            class={`${
              errors.categoryId &&
              "border-red-500 dark:border-red-600 focus:ring-2 focus:ring-red-500 dark:focus:ring-2 dark:focus:ring-red-600"
            } bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 `}
            onChange={handleChange}
          >
            {categoriesData.map((category) => {
              return (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              );
            })}
          </select>
          <p className="mt-2 text-sm font-medium text-red-600 dark:text-red-500">
            {errors.categoryId}
          </p>
        </div>
        <div className="mb-5">
          <div className="mb-2">
            <Label htmlFor="name" value="Name" />
          </div>
          <TextInput
            type="text"
            id="name"
            name="name"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required
            value={inputFields.name}
            color={errors.name && "failure"}
            helperText={
              errors.name && <span className="font-medium">{errors.name}</span>
            }
            onChange={handleChange}
          />
        </div>
        <div class="grid grid-cols-2 gap-6">
          <div class="mb-5">
            <div className="mb-2">
              <Label htmlFor="weight" value="Weight" />
            </div>
            <TextInput
              type="number"
              id="weight"
              name="weight"
              step="0.01"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              required
              value={inputFields.weight}
              color={errors.weight && "failure"}
              helperText={
                errors.weight && (
                  <span className="font-medium">{errors.weight}</span>
                )
              }
              onChange={handleChange}
            />
          </div>
          <div class="mb-5">
            <div className="mb-2">
              <Label htmlFor="cost" value="Cost" />
            </div>
            <TextInput
              type="number"
              id="cost"
              step="0.01"
              name="cost"
              class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
              required
              value={inputFields.cost}
              color={errors.cost && "failure"}
              helperText={
                errors.cost && (
                  <span className="font-medium">{errors.cost}</span>
                )
              }
              onChange={handleChange}
            />
          </div>
        </div>
        <Button type="submit" size="sm" onClick={handleSubmit}>
          Submit
        </Button>
      </>
    )
  );
}
