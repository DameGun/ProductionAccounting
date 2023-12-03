import { useLocation, Link } from "react-router-dom";
import { Button } from "flowbite-react";

export default function ProductTableItem({ product }) {
  const location = useLocation();

  const productRequestModel = {
    id: product.id,
    name: product.name,
    weight: product.weight,
    cost: product.cost,
    categoryId: product.category.id,
  };

  return (
    <div class="mt-2 w-3/4 bg-gray-500 dark:bg-gray-600 mx-auto border-gray-500 border rounded-md text-white mb-0.5 h-30">
      <div class="flex p-3">
        <div class="space-y-1 border-r-2 pr-3">
          <div class="text-sm leading-5 font-semibold">
            <span class="text-xs leading-4 font-normal text-gray-300">
              {" "}
              Id #
            </span>{" "}
            {product.id}
          </div>
        </div>
        <div class="flex-1">
          <div class="ml-3 space-y-1 border-r-2 pr-3">
            <div class="text-base leading-6 font-normal">{product.name}</div>
            <div class="text-sm leading-4 font-normal">
              <span class="text-xs leading-4 font-normal text-gray-300">
                {" "}
                Category
              </span>{" "}
              {product.category.name}
            </div>
            <div class="text-sm leading-4 font-normal">
              <span class="text-xs leading-4 font-normal text-gray-300">
                {" "}
                Weight
              </span>{" "}
              {product.weight}
            </div>
          </div>
        </div>
        <div class="flex items-center border-r-2 pr-3">
          <div>
            <div class="ml-3 my-3 border-gray-200 border-2 bg-gray-400 p-1 text-center">
              <div class="uppercase text-xs leading-4 font-medium">Cost</div>
              <div class="text-center text-sm leading-4 font-semibold text-gray-800">
                {product.cost} BYN
              </div>
            </div>
          </div>
        </div>
        <div className="flex items-center border-r-2 mx-2">
          <Link
            to={`/products/${product.id}/edit`}
            state={{
              backgroundLocation: location,
              product: productRequestModel,
              modalSize: "xl",
            }}
          >
            <Button color="blue" className="mr-2" size="xs">
              Edit
            </Button>
          </Link>
          <Link
            to={`/products/${product.id}/delete`}
            state={{
              backgroundLocation: location,
              itemId: product.id,
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
