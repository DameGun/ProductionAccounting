import { useNavigate } from "react-router-dom";
import { Pagination } from "flowbite-react";

export default function PaginationComponent({ metaData, pageSize }) {
  const navigate = useNavigate();

  const onPageChange = (number) => {
    navigate(`?PageNumber=${number}&PageSize=${pageSize}`);
  };

  return (
    <Pagination
    className="my-6"
      currentPage={metaData.currentPage}
      totalPages={metaData.totalPages}
      onPageChange={onPageChange}
    />
  );
}
