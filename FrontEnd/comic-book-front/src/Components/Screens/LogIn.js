import { Button, TextField } from "@mui/material";
import { Box } from "@mui/system";
import { useForm } from "react-hook-form";
import { Navigate } from "react-router-dom";
import { logIn } from "../../services/RegisterService";
export default function LogIn() {
    const { handleSubmit,register } = useForm()

    const onLogInSubmit = async (data) =>{
        const userBody = {
            email:data.email,
            password:data.password
        }
        const response = await logIn(userBody)
        if(response.status===201){
            Navigate('/')
        }
        else{
            alert(response.message)
        }
    }

    return (
        <Box sx={{width:'100%',display:'center',justifyContent: "center", alignItems: "center",marginTop:"5%"}}>
            <TextField 
            {...register("email")}/>
            <TextField 
            {...register("password")}
            type="password" />
            <Button onClick={handleSubmit(onLogInSubmit)}>Log in</Button>
        </Box>
    )
}