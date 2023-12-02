import { Outlet } from "react-router-dom";
import Nav from "../components/Nav";
import { Flowbite } from "flowbite-react";

export default function RootPage() {
  return (
    <Flowbite>
      <div className="bg-gray-100 dark:bg-gray-900 min-h-screen">
        <Nav />
        <Outlet />
      </div>
    </Flowbite>
  );
}
