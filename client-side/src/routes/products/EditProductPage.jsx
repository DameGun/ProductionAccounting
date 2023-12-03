import { useLocation } from "react-router-dom";
import { updateProduct } from "../../utils/api";
import { Alert } from "flowbite-react";
import { useState } from "react";
import ProductForm from "../../components/product/ProductForm";

export default function EditProductPage() {
  const { state } = useLocation();
  const product = state?.product;
  const [responseStatus, setResponseStatus] = useState(false);
  return (
    <>
      <ProductForm
        apiCall={updateProduct}
        setResponseStatus={setResponseStatus}
        currentProduct={product}
      />
      {responseStatus && (
        <Alert className="mt-5">Product was successfully updated!</Alert>
      )}
    </>
  );
}
