import { Link } from "react-router-dom";
import ApplicationForm from "../../components/application/ApplicationForm";
import { createApplication } from "../../utils/api";
import { useState } from "react";
import { Alert } from 'flowbite-react';

export default function CreateApplicationPage() {
  const [responseStatus, setResponseStatus] = useState(false);

  return (
    <div class="max-w-sm mx-auto mt-10">
      <ApplicationForm apiCall={createApplication} setResponseStatus={setResponseStatus}/>
      {responseStatus && (
        <Alert className="mt-5">
          Production application was successfully created! Go to{" "}
          <Link
            className="underline"
            to="/applications?PageNumber=1&PageSize=2"
          >
            applications
          </Link>
        </Alert>
      )}
    </div>
  );
}
