import ApplicationTableItem from "../components/ApplicationTableItem";
import { useLoaderData, useSearchParams } from "react-router-dom";
import Pagination from "../components/Pagination";

export default function ApplicationsPage() {
  const [searchParams] = useSearchParams();
  const pageSize = searchParams.get("PageSize");
  const { data, metaData } = useLoaderData();

  return (
    <div class={`container mx-auto flex flex-col items-center ga mt-10`}>
      {data ? (
        <>
          {data.map((application) => (
            <ApplicationTableItem application={application} />
          ))}
          <Pagination metaData={metaData} pageSize={pageSize}/>
        </>
      ) : (
        <p>
          <i>No applications</i>
        </p>
      )}
    </div>
  );
}
