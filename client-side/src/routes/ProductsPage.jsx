import { useLoaderData, useSearchParams } from "react-router-dom";
import TableHeader from "../components/TableHeader";
import ProductTableItem from "../components/ProductTableItem";
import PaginationComponent from "../components/Pagination";

export default function ProductsPage() { 
  const [searchParams] = useSearchParams();
  const pageSize = searchParams.get("PageSize");
  const { data, metaData } = useLoaderData();
  
  return (
    <div class="container mx-auto flex flex-col mt-10">
      <h1 class="font-bold text-xl text-center text-gray-600 dark:text-white">Products</h1>
      <TableHeader defaultPageSize={pageSize}/>
      <div class="flex flex-col items-center">
        {data ? (
          <>
            {data.map((product) => (
              <ProductTableItem product={product} />
            ))}
            <PaginationComponent metaData={metaData} pageSize={pageSize} />
          </>
        ) : (
          <p>
            <i>No products</i>
          </p>
        )}
      </div>
    </div>
  );
}
