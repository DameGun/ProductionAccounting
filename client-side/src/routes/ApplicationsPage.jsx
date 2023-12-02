import ApplicationTableItem from "../components/ApplicationTableItem";
import { useLoaderData, useSearchParams } from "react-router-dom";
import PaginationComponent from "../components/Pagination";
import TableHeader from "../components/TableHeader";

export default function ApplicationsPage() {
  const [searchParams] = useSearchParams();
  const pageSize = searchParams.get("PageSize");
  const { data, metaData } = useLoaderData();

  return (
    <div className="container mx-auto flex flex-col mt-10">
      <h1 className="font-bold text-xl text-center text-gray-600 dark:text-white">Applications</h1>
      <TableHeader defaultPageSize={pageSize} />
      <div className="flex flex-col items-center">
        {data ? (
          <>
            {data.map((application) => (
              <ApplicationTableItem key={application.id} application={application} />
            ))}
            <PaginationComponent metaData={metaData} pageSize={pageSize} />
          </>
        ) : (
          <p>
            <i>No applications</i>
          </p>
        )}
      </div>
    </div>
  );
}
