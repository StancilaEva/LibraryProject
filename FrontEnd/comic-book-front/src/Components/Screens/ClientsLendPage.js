import { useEffect, useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useParams } from "react-router-dom";
import LendCard from "../Cards/GridCards/LendCard";
import { Grid } from "@mui/material";
import api from "../../api/posts"
import { getAllClientLends } from "../../services/LendService";
import Pagination from "@mui/material/Pagination";
import { Box } from "@mui/system";
import { useNavigate } from "react-router";
function ClientLends() {
    const [lends, setLends] = useState([])
    const [page, setPage] = useState(1)
    const [noOfPAges, setNoOfPages] = useState(0)
    const navigate = useNavigate()

    const loadLends = async () => {
        const response = await getAllClientLends(page)
        if(response.status===401){
            localStorage.clear()
            navigate('/LogIn')
        } else {
        setLends(response.data.lends)
        setNoOfPages(Math.ceil(response.data.count / 8))
        }
    }

    useEffect(() => { loadLends() }, [page])

    return (
        <div>
            <ApplicationMenuBar />
            <Grid container spacing={3} marginLeft={"0.05%"} marginTop="0.05%" width="99%">
                {
                    lends.map((lend, index) => <Grid item xs={12} sm={6} md={3} key={index}><LendCard key={index} lend={lend}></LendCard></Grid>)
                }
            </Grid>
            <Box display={"flex"} justifyContent={"center"}>
            <Pagination count={noOfPAges} page={page} onChange={(evt, value) => { setPage(value) }} sx={{margin:'8px'}}/>
            </Box>
        </div>)
}
export default ClientLends;