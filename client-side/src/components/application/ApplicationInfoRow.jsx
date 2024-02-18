export default function ApplicationInfoRow({ name, value }) {
  return (
    <div class="flex flew-col gap-2">
      <p className="font-bold text-gray-700 dark:text-gray-400">{name}</p>
      <p className="font-normal text-gray-700 dark:text-gray-400">{value}</p>
    </div>
  );
}
