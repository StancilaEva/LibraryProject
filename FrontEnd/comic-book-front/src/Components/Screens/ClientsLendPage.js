import { useEffect, useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useParams } from "react-router-dom";
import LendCard from "../Cards/LendCard";
import { Grid } from "@mui/material";
import api from "../../api/posts"

function ClientLends() {
    let {id} = useParams()

    const [lends,setLends] = useState([])

    const loadLends = async () =>{
        const response = await api.get(`/Client/${id}/Lends`)
        if(response.status==200){
            var result = await response.data
            setLends(result)
            
        }
        else{
            alert(response.status)
        }
    }

    useEffect(()=>{loadLends()},[])

    return (
    <div>
        <ApplicationMenuBar/>
        <Grid container spacing={3} marginLeft={"0.05%"} marginTop="0.05%" width="99%">
            {
                lends.map((lend,index)=><Grid item xs={12} sm={6} md={3} key={index}><LendCard key={index} lend={lend}></LendCard></Grid>)
            }
        </Grid>
    </div>)
}
export default ClientLends;