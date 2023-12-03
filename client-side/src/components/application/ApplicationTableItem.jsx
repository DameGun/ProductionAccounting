import { Link, useLocation } from "react-router-dom";
import { Button } from "flowbite-react";

export default function ApplicationTableItem({ application }) {
  const location = useLocation();

  const applicationRequestModel = {
    id: application.id,
    productId: application.product.id,
    packagesInBox: application.packagesInBoxMax,
    boxesInPallet: application.boxesInPalletMax,
    prodDate: new Date(application.prodDate),
    expDate: new Date(application.expDate),
    currentApplicationState: application.currentApplicationState,
  };

  return (
    <div className="mt-2 w-3/4 bg-gray-500 dark:bg-gray-600 mx-auto border-gray-500 border rounded-md text-white mb-0.5 h-30">
      <div
        className={`flex p-3 border-l-8 ${
          application.currentApplicationState === 0
            ? "border-green-600"
            : "border-red-600"
        }`}
      >
        <div className="space-y-1 border-r-2 pr-3">
          <div className="text-sm leading-5 font-semibold">
            <span className="text-xs leading-4 font-normal text-gray-300">
              {" "}
              Id #
            </span>{" "}
            {application.id}
          </div>
          <div className="text-sm leading-5 font-semibold">
            <span className="text-xs leading-4 font-normal text-gray-300 pr">
              {" "}
              Product Id #
            </span>{" "}
            {application.product.id}
          </div>
          <div className="text-sm leading-5 font-semibold">
            <span className="text-xs leading-4 font-normal text-gray-300">
              {" "}
              Production Date #
            </span>{" "}
            {application.prodDate}
          </div>
          <div className="text-sm leading-5 font-semibold">
            <span className="text-xs leading-4 font-normal text-gray-300">
              {" "}
              Expire Date #
            </span>{" "}
            {application.expDate}
          </div>
        </div>
        <div className="flex-1">
          <div className="ml-3 space-y-1 border-r-2 pr-3">
            <div className="text-base leading-6 font-normal">
              {application.product.name}
            </div>
            <div className="text-sm leading-4 font-normal">
              <span className="text-xs leading-4 font-normal text-gray-300">
                {" "}
                Category
              </span>{" "}
              {application.product.category.name}
            </div>
            <div className="text-sm leading-4 font-normal">
              <span className="text-xs leading-4 font-normal text-gray-300">
                {" "}
                Packages in box
              </span>{" "}
              {application.packagesInBoxMax}
            </div>
            <div className="text-sm leading-4 font-normal">
              <span className="text-xs leading-4 font-normal text-gray-300">
                {" "}
                Boxes in pallet
              </span>{" "}
              {application.boxesInPalletMax}
            </div>
          </div>
        </div>
        <div className="flex items-center border-r-2 pr-3">
          <div>
            <div className="ml-3 my-3 border-gray-200 border-2 bg-gray-400 p-1">
              <div className="uppercase text-xs leading-4 font-medium">
                Units
              </div>
              <div className="text-center text-sm leading-4 font-semibold text-gray-800">
                NaN
              </div>
            </div>
          </div>
        </div>
        <div className="flex items-center border-r-2 mx-2">
          <Link
            to={`/applications/${application.id}/edit`}
            state={{
              backgroundLocation: location,
              application: applicationRequestModel,
              modalSize: "4xl",
            }}
          >
            <Button color="blue" className="mr-2" size="xs">
              Edit
            </Button>
          </Link>
          <Link
            to={`/applications/${application.id}/delete`}
            state={{
              backgroundLocation: location,
              itemId: application.id,
              modalSize: "sm",
            }}
          >
            <Button color="failure" className="mr-2" size="xs">
              Remove
            </Button>
          </Link>
        </div>
        <div className="flex items-center">
          <div
            className={`ml-3 my-5 p-1 w-20 ${
              application.currentApplicationState === 0
                ? "bg-green-600"
                : "bg-red-600"
            }`}
          >
            <div className="uppercase text-xs leading-4 font-semibold text-center text-yellow-100">
              {application.currentApplicationState === 0 ? "Active" : "Closed"}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
