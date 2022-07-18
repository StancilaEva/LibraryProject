import { Navigate } from "react-router"
import { getRole } from "../functions/ExtractFromToken"

const PrivateAdminRoute = ({ children }) => {
    var user = localStorage.getItem("token")
    if (!localStorage.getItem("token")) return <Navigate to="/LogIn" />
    const role = getRole(user)
    return role === "Admin" ? children : <Navigate to="/LogIn" />
}

export default PrivateAdminRoute