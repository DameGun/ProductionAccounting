import { createProduct } from "../../utils/api";
import { useState } from "react";
import { Alert } from "flowbite-react";
import ProductForm from "../../components/product/ProductForm";

export default function CreateProductPage() {
  const [responseStatus, setResponseStatus] = useState(false);

  return (
    <>
      <ProductForm
        apiCall={createProduct}
        setResponseStatus={setResponseStatus}
      />
      {responseStatus && (
        <Alert className="mt-5">Product was successfully created!</Alert>
      )}
    </>
  );
}
