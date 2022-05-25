import { Navigate } from "react-router"

const PrivateRoute = ({children}) =>{
    return localStorage.getItem("token")?children:<Navigate to="/LogIn"/>
}

export default PrivateRoute