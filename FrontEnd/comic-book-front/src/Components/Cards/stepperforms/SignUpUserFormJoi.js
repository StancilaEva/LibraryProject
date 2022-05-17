import { useForm } from "react-hook-form"
import { Box } from "@mui/system";
import { CardContent, Container } from "@mui/material";
import { TextField } from "@mui/material";
import { joiResolver } from '@hookform/resolvers/joi';
import React from "react";
import { Card } from "@mui/material";
import { Navigate, useNavigate } from "react-router-dom";

const SignUpForm = (props) => {
    const { setActiveStep, user, setUser,email,username,password,confirmPassword,errors } = props;


    console.log(errors)
    return (
        <>
        <Box sx={{width:'100%',display:'center',justifyContent: "center", alignItems: "center",marginTop:"5%"}}>
        <Card sx={{width:'50%', alignSelf:'center', justifySelf:'center' ,height:'60%'}}>
            <CardContent>
                <Box sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center", height: '65%' }}>
                    <TextField
                        {...email}
                        placeholder="Email"
                        sx={{ margin: "16px", wdith: "20%" }}
                        defaultValue={user.email}
                        onChange={(event)=>setUser({...user,email:event.target.value})}
                        helperText={errors ? errors.email?.message : null}
                    />
                    <TextField
                        {...username}
                        placeholder="Username"
                        type="text"
                        defaultValue={user.username}
                        sx={{ margin: "16px", wdith: "20%" }}
                        onChange={(event)=>setUser({...user,username:event.target.value})}
                        helperText={errors ? errors.username?.message : null} />
                    <TextField
                        {...password}
                        placeholder="Password"
                        type="password"
                        defaultValue={user.password}
                        sx={{ margin: "16px", wdith: "20%" }}
                        onChange={(event)=>setUser({...user,password:event.target.value})}
                        helperText={errors ? errors.password?.message : null}
                    />
                    <TextField
                        {...confirmPassword}
                        placeholder="Confirm Password"
                        type="password"
                        sx={{ margin: "16px", wdith: "20%" }}
                        helperText={errors ? errors.confirmPassword?.message : null}
                    />
                </Box>
            </CardContent>
        </Card>
        </Box>
        </>
    )
}
export default SignUpForm