import { useLocation, Link } from "react-router-dom";
import { Button } from "flowbite-react";

export default function CategoryTableItem({ category }) {
  const location = useLocation();

  return (
    <div class="mt-2 w-3/4 bg-gray-500 dark:bg-gray-600 mx-auto border-gray-500 border rounded-md text-white mb-0.5 h-30">
      <div class="flex p-3">
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
            <div class="text-base leading-6 font-normal">{category.name}</div>
          </div>
        </div>
        <div class="flex items-center border-r-2 mx-2">
          <Link
            to={`/categories/${category.id}/edit`}
            state={{
              backgroundLocation: location,
              category: category,
              modalSize: "sm",
            }}
          >
            <Button color="blue" className="mr-2" size="xs">
              Edit
            </Button>
          </Link>
          <Link
            to={`/categories/${category.id}/delete`}
            state={{
              backgroundLocation: location,
              itemId: category.id,
              modalSize: "sm",
            }}
          >
            <Button color="failure" className="mr-2" size="xs">
              Remove
            </Button>
          </Link>
        </div>
        <div class="flex items-center"></div>
      </div>
    </div>
  );
}
