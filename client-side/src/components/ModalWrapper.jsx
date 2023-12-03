import { Modal } from "flowbite-react";
import { useNavigate } from "react-router-dom";

export default function ModalWrapper({ modalSize, children }) {
  const navigate = useNavigate();

  return (
    <>
      <Modal
        show={true}
        size={modalSize}
        onClose={() => navigate(-1)}
        popup
      >
        <Modal.Header />
        <Modal.Body class="overflow-visible px-10 py-5">
          <div className="text-center">
            {children}
          </div>
        </Modal.Body>
      </Modal>
    </>
  );
}
