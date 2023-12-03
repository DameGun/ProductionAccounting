import { useState } from "react";
import { Alert } from "flowbite-react";
import CategoryForm from "../../components/category/CategoryForm";
import { createCategory } from "../../utils/api";

export default function CreateCategoryPage() {
  const [responseStatus, setResponseStatus] = useState(false);

  return (
    <>
      <CategoryForm
        apiCall={createCategory}
        setResponseStatus={setResponseStatus}
      />
      {responseStatus && (
        <Alert className="mt-5">Product was successfully created!</Alert>
      )}
    </>
  );
}
