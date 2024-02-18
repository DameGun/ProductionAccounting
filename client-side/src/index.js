import React from "react";
import ReactDOM from "react-dom/client";
import "./styles.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import RootPage from "./routes/RootPage";
import ErrorPage from "./routes/ErrorPage";
import ApplicationsPage from "./routes/applications/ApplicationsPage";
import {
  deleteApplication,
  deleteCategory,
  deleteProduct,
  getApplicationById,
  getApplications,
  getCategories,
  getProducts,
  setActiveApplication,
} from "./utils/api";
import ProductsPage from "./routes/products/ProductsPage";
import CategoriesPage from "./routes/categories/CategoriesPage";
import CreateApplicationPage from "./routes/applications/CreateApplicationPage";
import ModalLayout from "./routes/ModalLayout";
import EditApplicationPage from "./routes/applications/EditApplicationPage";
import DeletePage from "./routes/DeletePage";
import EditProductPage from "./routes/products/EditProductPage";
import CreateProductPage from "./routes/products/CreateProductPage";
import CreateCategoryPage from "./routes/categories/CreateCategoryPage";
import EditCategoryPage from "./routes/categories/EditCategoryPage";
import ActiveApplicationPage from "./routes/applications/ActiveApplicationPage";

async function tableLoaderWithPagination(apiCall, request) {
  const url = new URL(request.url);
  const pageNumber = url.searchParams.get("PageNumber");
  const pageSize = url.searchParams.get("PageSize");
  return await apiCall(pageNumber, pageSize);
}

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootPage />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "applications",
        element: <ModalLayout />,
        children: [
          {
            path: "",
            element: <ApplicationsPage />,
            loader: async ({ request }) =>
              await tableLoaderWithPagination(getApplications, request),
          },
          {
            path: ":applicationId",
            element: <ActiveApplicationPage />,
            loader: async ({ params }) =>
              await setActiveApplication(params.applicationId),
          },
          {
            path: "create",
            element: <CreateApplicationPage />,
          },
          {
            path: ":applicationId/edit",
            element: <EditApplicationPage />,
          },
          {
            path: ":applicationId/delete",
            element: <DeletePage apiCall={deleteApplication} />,
          },
        ],
      },
      {
        path: "products",
        element: <ModalLayout />,
        children: [
          {
            path: "",
            element: <ProductsPage />,
            loader: async ({ request }) =>
              await tableLoaderWithPagination(getProducts, request),
          },
          {
            path: "create",
            element: <CreateProductPage />,
          },
          {
            path: ":productId/edit",
            element: <EditProductPage />,
          },
          {
            path: ":productId/delete",
            element: <DeletePage apiCall={deleteProduct} />,
          },
        ],
      },
      {
        path: "categories",
        element: <ModalLayout />,
        children: [
          {
            path: "",
            element: <CategoriesPage />,
            loader: async ({ request }) =>
              await tableLoaderWithPagination(getCategories, request),
          },
          {
            path: "create",
            element: <CreateCategoryPage />,
          },
          {
            path: ":categoryId/edit",
            element: <EditCategoryPage />,
          },
          {
            path: ":categoryId/delete",
            element: <DeletePage apiCall={deleteCategory} />,
          },
        ],
      },
    ],
  },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
