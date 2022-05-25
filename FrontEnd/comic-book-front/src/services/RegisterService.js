
import api from "../api/posts"

export const signUpUser = async (signUpInfo) =>{
    let jsonMessage={
        status:0,
        message:"",
        token:null
    };
    await api.post("/Identity/SignUp",signUpInfo)
    .then((result)=>{
        jsonMessage.status = result.status
        jsonMessage.token = result.data.token
        jsonMessage.message = "Sign up successful!"
    })
    .catch((err)=>{
        jsonMessage.status = err.response.status
        jsonMessage.message = err.response.data.errorMessage
    })
    return jsonMessage
}

export const logIn = async (logInInfo) =>{
    let jsonMessage ={
        status:0,
        message:"",
        token:null
    }
    await api.post("/Identity/LogIn",logInInfo)
    .then((result)=>{
        jsonMessage.status = result.status
        jsonMessage.message = "login in successful!"
        jsonMessage.token = result.data.token
    })
    .catch((err)=>{
        jsonMessage.status = err.response.status
        jsonMessage.message = err.response.data.errorMessage
    })

    return jsonMessage
}