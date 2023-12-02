import { Form, NavLink } from "react-router-dom";
import { Button, DarkThemeToggle, Navbar, NavbarBrand } from "flowbite-react";
import { HiOutlinePlus } from "react-icons/hi";

export default function Nav() {
  return (
    <Navbar fluid rounded>
      <div className="container flex flex-row justify-between">
        <div className="flex space-x-4 items-center">
          <NavbarBrand as={NavLink} to="/">
            <img
              className="h-8 w-auto"
              src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=500"
              alt="Your Company"
            />
          </NavbarBrand>
          <NavLink
            to="applications?PageNumber=1&PageSize=2"
            className={({ isActive }) =>
              isActive
                ? "border-none bg-gray-600 text-white dark:bg-gray-900 dark:text-white rounded-md px-3 py-2 text-sm font-medium"
                : "text-gray-600 hover:bg-gray-500 hover:text-white  dark:border-none dark:text-gray-300 dark:hover:bg-gray-700 dark:hover:text-white rounded-md px-3 py-2 text-sm font-medium"
            }
            aria-current="page"
          >
            Applications
          </NavLink>
          <NavLink
            to="products?PageNumber=1&PageSize=10"
            className={({ isActive }) =>
              isActive
                ? "border-none bg-gray-600 text-white dark:bg-gray-900 dark:text-white rounded-md px-3 py-2 text-sm font-medium"
                : "text-gray-600 hover:bg-gray-500 hover:text-white  dark:border-none dark:text-gray-300 dark:hover:bg-gray-700 dark:hover:text-white rounded-md px-3 py-2 text-sm font-medium"
            }
            aria-current="page"
          >
            Products
          </NavLink>
          <NavLink
            to="categories?PageNumber=1&PageSize=2"
            className={({ isActive }) =>
              isActive
                ? "border-none bg-gray-600 text-white dark:bg-gray-900 dark:text-white rounded-md px-3 py-2 text-sm font-medium"
                : "text-gray-600 hover:bg-gray-500 hover:text-white  dark:border-none dark:text-gray-300 dark:hover:bg-gray-700 dark:hover:text-white rounded-md px-3 py-2 text-sm font-medium"
            }
            aria-current="page"
          >
            Categories
          </NavLink>
        </div>

        <div className="flex space-x-4">
          <NavLink to="applications/create">
            <Button size="sm" color="purple">
              <HiOutlinePlus className="mr-2 h-5 w-5" />
              Create application
            </Button>
          </NavLink>
          <Navbar.Toggle />
          <DarkThemeToggle />
        </div>
      </div>
    </Navbar>
  );
}
