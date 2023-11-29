import { Outlet } from "react-router-dom";
import Nav from "../components/Nav";

export default function RootPage() {
    return (
        <div class="bg-gray-300 h-screen">
            <Nav/>
            <Outlet/>
        </div>
    )
}