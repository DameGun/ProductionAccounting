import { useLocation, useNavigate } from "react-router-dom";
import { Button } from "flowbite-react";
import { HiOutlineExclamationCircle } from "react-icons/hi";

export default function DeletePage({ apiCall }) {
  const { state } = useLocation();
  const navigate = useNavigate();

  async function handleDelete() {
    await apiCall(state.itemId);
    navigate(-1);
  }

  return (
    <>
      <HiOutlineExclamationCircle className="mx-auto mb-4 h-14 w-14 text-gray-400 dark:text-gray-200" />
      <h3 className="mb-5 text-lg font-normal text-gray-500 dark:text-gray-400">
        Are you sure you want to delete this item?
      </h3>
      <div className="flex justify-center gap-4">
        <Button color="failure" onClick={handleDelete}>
          Yeah, i'm sure
        </Button>
      </div>
    </>
  );
}
