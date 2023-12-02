import React from 'react';
import ReactDOM from 'react-dom/client';
import './styles.css';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import RootPage from './routes/RootPage'; 
import ErrorPage from './routes/ErrorPage';
import ApplicationsPage from './routes/ApplicationsPage';
import { getApplications, getCategories, getProducts } from './utils/api';
import ProductsPage from './routes/ProductsPage';
import CategoriesPage from './routes/CategoriesPage';
import CreateApplicationPage from './routes/CreateApplicationPage';

async function tableLoaderWithPagination (apiCall, request) {
  const url = new URL(request.url);
  const pageNumber = url.searchParams.get('PageNumber');
  const pageSize = url.searchParams.get('PageSize');
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
        element: <ApplicationsPage />,
        loader: async ({ request }) => await tableLoaderWithPagination(getApplications, request)
      },
      {
        path: "applications/create",
        element: <CreateApplicationPage />,
        loader: async () => {
          return await getProducts(1, 1000);
        }
      },
      {
        path: "products",
        element: <ProductsPage />,
        loader: async ({ request }) => await tableLoaderWithPagination(getProducts, request)
      },
      {
        path: "categories",
        element: <CategoriesPage />,
        loader: async ({ request }) => await tableLoaderWithPagination(getCategories, request)
      }
    ]
  }
])

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
