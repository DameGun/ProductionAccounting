import { NavLink } from "react-router-dom";

export default function Nav() {
  return (
    <nav class="bg-gray-800">
      <div class="mx-auto max-w-7xl px-2 lg:px-8">
        <div class="flex h-16 items-center justify-between">
          <div class="flex flex-1 items-center justify-start">
            <div class="flex flex-shrink-0 items-center">
              <NavLink to={`/`}>
                <img
                  class="h-8 w-auto"
                  src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=500"
                  alt="Your Company"
                />
              </NavLink>
            </div>

            {/* Nav buttons */}
            <div class="ml-6 block">
              <div class="flex space-x-4">
                <NavLink
                  to="applications?PageNumber=1&PageSize=1"
                  className={({ isActive }) =>
                    isActive
                      ? "bg-gray-900 text-white rounded-md px-3 py-2 text-sm font-medium"
                      : "text-gray-300 hover:bg-gray-700 hover:text-white rounded-md px-3 py-2 text-sm font-medium"
                  }
                  aria-current="page"
                  value="Applications"
                >
                  Applications
                </NavLink>
              </div>
            </div>
          </div>

          <div>
            <NavLink
              href="#"
              class="inline-flex items-center bg-indigo-500 text-white hover:bg-indigo-600 rounded-md px-3 py-2 gap-1 text-sm font-medium"
              aria-current="page"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                strokeWidth={1.5}
                stroke="currentColor"
                className="w-5 h-5"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  d="M12 6v12m6-6H6"
                />
              </svg>
              <span>Create application</span>
            </NavLink>
          </div>
        </div>
      </div>
    </nav>
  );
}
