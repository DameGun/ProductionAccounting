export default function TableWrapper({ thead, tbody }) {
  return (
    <div class="mt-5 overflow-x-auto shadow-md rounded-lg">
      <table class="text-sm text-left text-gray-500">
        <thead class="text-xs text-gray-400 uppercase bg-gray-50 dark:bg-gray-700">
          {thead}
        </thead>
        <tbody class="bg-white">
          {tbody}
        </tbody>
      </table>
    </div>
  );
}
