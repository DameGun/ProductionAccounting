export default function ApplicationTableItem({ application }) {
  return (
    <div class="mt-2 w-3/4 bg-gray-100 mx-auto border-gray-500 border rounded-md text-gray-700 mb-0.5 h-30">
      <div
        class={`flex p-3 border-l-8 ${
          application.currentApplicationState === 0
            ? "border-green-600"
            : "border-red-600"
        }`}
      >
        <div class="space-y-1 border-r-2 pr-3">
          <div class="text-sm leading-5 font-semibold">
            <span class="text-xs leading-4 font-normal text-gray-500">
              {" "}
              Id #
            </span>{" "}
            {application.id}
          </div>
          <div class="text-sm leading-5 font-semibold">
            <span class="text-xs leading-4 font-normal text-gray-500 pr">
              {" "}
              Product Id #
            </span>{" "}
            {application.product.id}
          </div>
          <div class="text-sm leading-5 font-semibold">
            <span class="text-xs leading-4 font-normal text-gray-500">
              {" "}
              Production Date #
            </span>{" "}
            {application.prodDate}
          </div>
          <div class="text-sm leading-5 font-semibold">
            <span class="text-xs leading-4 font-normal text-gray-500">
              {" "}
              Expire Date #
            </span>{" "}
            {application.expDate}
          </div>
        </div>
        <div class="flex-1">
          <div class="ml-3 space-y-1 border-r-2 pr-3">
            <div class="text-base leading-6 font-normal">
              {application.product.name}
            </div>
            <div class="text-sm leading-4 font-normal">
              <span class="text-xs leading-4 font-normal text-gray-500">
                {" "}
                Category
              </span>{" "}
              {application.product.category.name}
            </div>
            <div class="text-sm leading-4 font-normal">
              <span class="text-xs leading-4 font-normal text-gray-500">
                {" "}
                Packages in box
              </span>{" "}
              {application.packagesInBoxMax}
            </div>
            <div class="text-sm leading-4 font-normal">
              <span class="text-xs leading-4 font-normal text-gray-500">
                {" "}
                Boxes in pallet
              </span>{" "}
              {application.boxesInPalletMax}
            </div>
          </div>
        </div>
        <div class="flex items-center border-r-2 pr-3">
          <div>
            <div class="ml-3 my-3 border-gray-200 border-2 bg-gray-300 p-1">
              <div class="uppercase text-xs leading-4 font-medium">Units</div>
              <div class="text-center text-sm leading-4 font-semibold text-gray-800">
                NaN
              </div>
            </div>
          </div>
        </div>
        <div class="flex items-center border-r-2">
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
          <div
            class={`ml-3 my-5 p-1 w-20 ${
              application.currentApplicationState === 0
                ? "bg-green-600"
                : "bg-red-600"
            }`}
          >
            <div class="uppercase text-xs leading-4 font-semibold text-center text-yellow-100">
              {application.currentApplicationState === 0 ? "Active" : "Closed"}
            </div>
          </div>
          <button class="text-gray-100 rounded-sm my-5 ml-2 focus:outline-none bg-indigo-500">
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
          </button>
        </div>
      </div>
    </div>
  );
}
