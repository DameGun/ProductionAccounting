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
import { getApplications } from './utils/api';

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootPage />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: "applications",
        element: <ApplicationsPage />,
        loader: async ({ request }) => {
          const url = new URL(request.url);
          const pageNumber = url.searchParams.get('PageNumber');
          const pageSize = url.searchParams.get('PageSize');
          return await getApplications(pageNumber, pageSize);
        }
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
