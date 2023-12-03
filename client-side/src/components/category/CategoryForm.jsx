import { useEffect, useState } from "react";
import { Label, TextInput, Button } from "flowbite-react";

export default function CategoryForm({
  apiCall,
  setResponseStatus,
  currentCategory,
}) {
  const [name, setName] = useState("");

  useEffect(() => {
    if (currentCategory) setName(currentCategory.name);
  }, []);

  function handleChange(e) {
    setName(e.target.value);
  }

  async function handleSubmit(e) {
    e.preventDefault();
    if (currentCategory)
      await apiCall({ id: currentCategory.id, name: name });
    else await apiCall({ name: name });
    setResponseStatus(true);
  }

  return (
    <>
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
          value={name}
          onChange={handleChange}
        />
      </div>
      <Button type="submit" size="sm" onClick={handleSubmit}>
        Submit
      </Button>
    </>
  );
}
