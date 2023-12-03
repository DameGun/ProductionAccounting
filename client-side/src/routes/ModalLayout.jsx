import { useLocation, Outlet } from "react-router-dom";
import ModalWrapper from "../components/ModalWrapper";

export default function ModalLayout() {
  const { state } = useLocation();

  return state?.backgroundLocation ? (
    <ModalWrapper modalSize={state.modalSize}>
      <Outlet/>
    </ModalWrapper>
  ) : (
    <Outlet />
  );
}
