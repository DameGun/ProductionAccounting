import { useNavigate } from "react-router-dom";

export default function Pagination({ metaData, pageSize }) {
  const navigate = useNavigate();

  const changePage = (number) => {
    if (metaData.currentPage === number) return;
    navigate(`/applications?PageNumber=${number}&PageSize=${pageSize}`);
  };

  const onPageNumberClick = (pageNumber) => {
    changePage(pageNumber);
  };

  const onPreviousPageClick = () => {
    changePage(metaData.currentPage - 1);
  };

  const onNextPageClick = () => {
    changePage(metaData.currentPage + 1);
  };


  const pageNumbers = [...new Array(metaData.totalPages)].map((_, index) => {
    const pageNumber = index + 1;
    const isPageNumberFirst = pageNumber === 1;
    const isPageNumberLast = pageNumber === metaData.totalPages;
    const isCurrentPageWithinTwoPageNumbers =
      Math.abs(pageNumber - metaData.currentPage) <= 2;

    if (
      isPageNumberFirst ||
      isPageNumberLast ||
      isCurrentPageWithinTwoPageNumbers
    ) {
      return (
        <li>
          <button
            class={`flex items-center justify-center px-4 h-10 border ${
              pageNumber === metaData.currentPage
                ? "text-white border-gray-700 bg-gray-700 "
                : "text-gray-400 hover:bg-gray-700 bg-gray-800 border-gray-700 hover:text-white "
            }}`}
            key={pageNumber}
            onClick={() => onPageNumberClick(pageNumber)}
          >
            {pageNumber}
          </button>
        </li>
      );
    }
    return null;
  });

  return (
    <nav class="mt-10">
      <ul class="inline-flex -space-x-px text-base h-10">
        <li>
          <button
            onClick={onPreviousPageClick}
            disabled={!metaData.hasPrevious}
            class="flex items-center justify-center px-4 h-10 ms-0 leading-tight text-gray-500 bg-white border border-e-0 border-gray-300 rounded-s-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
          >
            Previous
          </button>
        </li>
        {pageNumbers}
        <li>
          <button
            onClick={onNextPageClick}
            disabled={!metaData.hasNext}
            class="flex items-center justify-center px-4 h-10 leading-tight text-gray-500 bg-white border border-gray-300 rounded-e-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white"
          >
            Next
          </button>
        </li>
      </ul>
    </nav>
  );
}
