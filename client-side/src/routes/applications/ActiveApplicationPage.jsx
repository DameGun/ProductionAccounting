import { useLoaderData } from "react-router-dom";
import { Card, Button } from "flowbite-react";
import { HiOutlinePause, HiOutlinePlus } from "react-icons/hi";
import { useEffect, useState } from "react";
import ApplicationInfoRow from "../../components/application/ApplicationInfoRow";
import {
  createProductionUnit,
  getApplicationById,
  updateApplication,
} from "../../utils/api";

export default function ActiveApplicationPage() {
  const application = useLoaderData();
  const [count, setCount] = useState(
    application.packagesInBoxMax -
      (application.totalBoxes * application.packagesInBoxMax -
        application.totalUnits)
  );
  const [countBoxes, setCountBoxes] = useState(0);
  const [totalUnits, setTotalUnits] = useState(application.totalUnits);
  const [totalBoxes, setTotalBoxes] = useState(application.totalBoxes);
  const [totalPallets, setTotalPallets] = useState(application.totalPallets);

  const [stopped, setStopped] = useState(false);
  const [clicks, setClicks] = useState(0);
  const [buffApplication, setBuffApplication] = useState();

  const apiCall = async () => {
    console.log("call");
    const response = await createProductionUnit({
      currentBoxQuantity: count,
      currentPalletQuantity: countBoxes,
    });
    console.log(response);
    setTotalBoxes(response.totalBoxes);
    setTotalUnits(response.totalUnits);
    setTotalPallets(response.totalPallets);
  };

  useEffect(() => {}, []);

  useEffect(() => {
    console.log("effect");
    if (count !== 0 && clicks !== 0) {
      console.log("step 2");
      apiCall();
    }
  }, [count]);

  function handleClick() {
    if (count === application.packagesInBoxMax) {
      setCount(0);
    } else {
      setCount(count + 1);
    }

    if (countBoxes === application.boxesInPalletMax) {
      setCountBoxes(0);
    }

    setClicks(clicks + 1);
  }

  useEffect(() => {
    const fetchApplication = async () => {
      let buff = await getApplicationById(application.id);
      setBuffApplication(buff);
    };

    fetchApplication();

    if (buffApplication) {
      const requestObject = {
        ...buffApplication,
        totalUnits: totalUnits,
        totalBoxes: totalBoxes,
        totalPallets: totalPallets,
        productId: buffApplication.product.id,
        boxesInPallet: buffApplication.boxesInPalletMax,
        packagesInBox: buffApplication.packagesInBoxMax,
        currentApplicationState: 2,
      };
      delete requestObject.boxesInPalletMax;
      delete requestObject.packagesInBoxMax;
      delete requestObject.product;
      updateApplication(requestObject);
    }
  }, [stopped]);

  async function handleStop() {
    setStopped(true);
  }

  return (
    <div class="container mx-auto mt-20 px-96 grid grid-cols-2">
      <div class="flex flex-row justify-center">
        <Card className="max-w-sm p-10">
          <div class="flex flex-col gap-10 items-center">
            <div class="flex flex-row gap-2 justify-center">
              <h5 className="text-2xl font-bold tracking-tight text-gray-900 dark:text-white text-center">
                Counter:
              </h5>
              <h5 className="text-2xl font-normal tracking-tight text-gray-900 dark:text-white text-center">
                {count}
              </h5>
            </div>
            <div>
              <Button
                disabled={
                  application.currentApplicationState === 0 ? false : true
                }
                onClick={handleClick}
              >
                <HiOutlinePlus className="mr-2 h-5 w-5" />
                Create production unit
              </Button>
            </div>
            <div className="mt-2">
              <Button
                disabled={
                  application.currentApplicationState === 0 ? false : true
                }
                onClick={handleStop}
                color="failure"
              >
                <HiOutlinePause className="mr-2 h-5 w-5" />
                Stop production
              </Button>
            </div>
          </div>
        </Card>
      </div>
      <div className="flex flex-row justify-center">
        <Card className="max-w-sm p-5">
          <ApplicationInfoRow
            name="State:"
            value={
              application.currentApplicationState === 0 ? "Active" : "Stopped"
            }
          />
          <ApplicationInfoRow
            name="Product name:"
            value={application.product.name}
          />
          <ApplicationInfoRow
            name="Product category:"
            value={application.product.category.name}
          />
          <ApplicationInfoRow
            name="Packages in box:"
            value={application.packagesInBoxMax}
          />
          <ApplicationInfoRow
            name="Boxes in pallet:"
            value={application.boxesInPalletMax}
          />
          <ApplicationInfoRow name="Total units:" value={totalUnits} />
          <ApplicationInfoRow name="Total boxes:" value={totalBoxes} />
          <ApplicationInfoRow name="Total pallets:" value={totalPallets} />
        </Card>
      </div>
    </div>
  );
}
