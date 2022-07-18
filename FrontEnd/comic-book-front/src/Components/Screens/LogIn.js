import { Button, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useContext } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../Context/userContext";
import { logIn } from "../../services/RegisterService";
import { Collapse } from "@mui/material";
import UnsuccessfulMessage from "../Cards/Toasts/UnsuccessfulMessage";
import { useState } from "react";
import { Link } from "react-router-dom";
import { joiResolver } from '@hookform/resolvers/joi';
import { logInSchema } from "../../validators/logInSchema";

export default function LogIn() {
    const { user, setUser } = useContext(UserContext)
    const { handleSubmit, register, formState: { errors } } = useForm({ resolver: joiResolver(logInSchema) })
    const navigate = useNavigate()
    const [showMessage, setShowMessage] = useState(false)
    const [message, setMessage] = useState('')
    const [status, setStatus] = useState(0)

    const onLogInSubmit = async (data) => {
        const userBody = {
            email: data.email,
            password: data.password
        }
        const response = await logIn(userBody)
        setStatus(response.status)
        setMessage(response.message)
        if (response.status === 200) {
            localStorage.setItem("token", response.token)
            let jwtData = response.token.split('.')[1]
            let decodedJwtJsonData = window.atob(jwtData)
            let decodedJwtData = JSON.parse(decodedJwtJsonData)
            const role = decodedJwtData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
            if (role === "Admin") {
                navigate('/Admin')
            }
            else {
                navigate('/')
            }
        }
        else {
            setShowMessage(true)
        }
    }

    const renderToast = () => {
        return (<UnsuccessfulMessage setShowMessage={setShowMessage} message={message} showMessage={showMessage} />)
    }

    return (
        <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", height: '75vh' }} >
            <TextField
                {...register("email")}
                helperText={errors ? errors.email?.message : null} />
            <TextField
                {...register("password")}
                helperText={errors ? errors.password?.message : null}
                type="password" />
            <Button onClick={handleSubmit(onLogInSubmit)}>Log in</Button>
            <Link to="/SignUp">Don't have an account? Sign Up!</Link>
            <Collapse in={showMessage}>
                {
                    renderToast()
                }
            </Collapse>
        </Box>
    )
}