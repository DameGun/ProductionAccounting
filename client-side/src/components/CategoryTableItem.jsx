export default function CategoryTableItem({ category }) {
    return (
        <div class="mt-2 w-3/4 bg-gray-500 dark:bg-gray-600 mx-auto border-gray-500 border rounded-md text-white mb-0.5 h-30">
          <div
            class="flex p-3"
          >
            <div class="space-y-1 border-r-2 pr-3">
              <div class="text-sm leading-5 font-semibold">
                <span class="text-xs leading-4 font-normal text-gray-300">
                  {" "}
                  Id #
                </span>{" "}
                {category.id}
              </div>
            </div>
            <div class="flex-1">
              <div class="ml-3 space-y-1 border-r-2 pr-3">
                <div class="text-base leading-6 font-normal">
                  {category.name}
                </div>
              </div>
            </div>
            <div class="flex items-center">
              <div class="mx-2">
                <button class="bg-blue-500 text-white hover:bg-blue-600 rounded-md px-2 py-1 text-sm font-medium mr-2">
                  Edit
                </button>
                <button class="bg-red-500 text-white hover:bg-red-600 rounded-md px-2 py-1 text-sm font-medium">
                  Remove
                </button>
              </div>
            </div>
            <div class="flex items-center">
              {/* <button class="text-gray-100 rounded-sm my-5 ml-2 focus:outline-none bg-indigo-500">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  class="h-6 w-6"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M19 9l-7 7-7-7"
                  />
                </svg>
              </button> */}
            </div>
          </div>
        </div>
      );
}