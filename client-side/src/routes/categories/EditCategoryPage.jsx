import { useState } from "react";
import { useLocation } from "react-router-dom";
import { Alert } from "flowbite-react";
import CategoryForm from "../../components/category/CategoryForm";
import { updateCategory } from "../../utils/api";

export default function EditCategoryPage() {
  const { state } = useLocation();
  const category = state?.category;
  const [responseStatus, setResponseStatus] = useState(false);

  return (
    <>
      <CategoryForm
        apiCall={updateCategory}
        setResponseStatus={setResponseStatus}
        currentCategory={category}
      />
      {responseStatus && (
        <Alert className="mt-5">Category was successfully updated!</Alert>
      )}
    </>
  );
}
