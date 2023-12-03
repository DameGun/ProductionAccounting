import { useLocation } from "react-router-dom";
import ApplicationForm from "../../components/application/ApplicationForm";
import { updateApplication } from "../../utils/api";
import { Alert } from "flowbite-react";
import { useState } from "react";

export default function EditApplicationPage() {
  const { state } = useLocation();
  const application = state?.application;
  const [responseStatus, setResponseStatus] = useState(false);

  return (
    <>
      <ApplicationForm
        apiCall={updateApplication}
        currentApplication={application}
        setResponseStatus={setResponseStatus}
      />
      {responseStatus && (
        <Alert className="mt-5">
          Production application was successfully updated!
        </Alert>
      )}
    </>
  );
}
