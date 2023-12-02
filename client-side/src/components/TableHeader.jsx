import { useNavigate } from "react-router-dom";

export default function TableHeader({ defaultPageSize }) {
  const navigate = useNavigate();
  const pageSizeValues = [2, 5, 10, 20];

  function handleChange(e) {
    navigate(`?PageNumber=1&PageSize=${e.target.value}`);
  }

  return (
    <div className="flex flex-row justify-around items-center my-5">
      <div>
        <label
          htmlFor="elements"
          className="block mb-2 text-sm font-medium text-gray-600 dark:text-white"
        >
          Number of elements
        </label>
        <select
          defaultValue={defaultPageSize}
          onChange={handleChange}
          id="elements"
          className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
        >
          {pageSizeValues.map((value) => (
            <option key={value} value={value}>{value}</option>
          ))}
        </select>
      </div>
      <div></div>
    </div>
  );
}
