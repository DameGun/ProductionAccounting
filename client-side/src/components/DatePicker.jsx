import { Datepicker } from "flowbite-react";

export function DatePicker({ handleChange, name, error }) {
  return (
    <>
      <Datepicker
        className={
          error &&
          "border disabled:cursor-not-allowed disabled:opacity-50 border-red-500 bg-red-50 text-red-900 placeholder-red-700 focus:border-red-500 focus:ring-red-500 dark:border-red-400 dark:bg-red-100 dark:focus:border-red-500 dark:focus:ring-red-500 text-sm rounded-lg"
        }
        name={name}
        onSelectedDateChanged={(date) =>
          handleChange({
            target: {
              name: name,
              value: date,
            },
          })
        }
      />
      <p className="mt-2 text-sm font-medium text-red-600 dark:text-red-500">
        {error}
      </p>
    </>
  );
}
