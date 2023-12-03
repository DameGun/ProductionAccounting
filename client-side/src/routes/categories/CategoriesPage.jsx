import {
  useLoaderData,
  useSearchParams,
  Link,
  useLocation,
} from "react-router-dom";
import TableHeader from "../../components/TableHeader";
import CategoryTableItem from "../../components/category/CategoryTableItem";
import PaginationComponent from "../../components/Pagination";
import { Button } from "flowbite-react";
import { HiOutlinePlus } from "react-icons/hi";

export default function CategoriesPage() {
  const [searchParams] = useSearchParams();
  const pageSize = searchParams.get("PageSize");
  const { data, metaData } = useLoaderData();
  const location = useLocation();

  return (
    <div class="container mx-auto flex flex-col mt-10">
      <h1 class="font-bold text-xl text-center text-gray-600 dark:text-white">
        Categories
      </h1>
      <div className="flex flex-row justify-around items-center my-5">
        <TableHeader defaultPageSize={pageSize} />
        <Link to={`create`} state={{ backgroundLocation: location, modalSize: "sm" }}>
          <Button size="sm" color="purple">
            <HiOutlinePlus className="mr-2 h-5 w-5" />
            Create category
          </Button>
        </Link>
      </div>

      <div class="flex flex-col items-center">
        {data ? (
          <>
            {data.map((category) => (
              <CategoryTableItem category={category} />
            ))}
            <PaginationComponent metaData={metaData} pageSize={pageSize} />
          </>
        ) : (
          <p>
            <i>No categories</i>
          </p>
        )}
      </div>
    </div>
  );
}
