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
import TimeFilter from "../Cards/FilterInputs/TimeFilter";
function ClientLends() {
    const [lends, setLends] = useState([])
    const [page, setPage] = useState(1)
    const [noOfPAges, setNoOfPages] = useState(0)
    const [filterTime,setFilterTime] = useState("")

    const navigate = useNavigate()

    const loadLends = async () => {
        const response = await getAllClientLends(page,filterTime)
        if(response.status===401){
            localStorage.clear()
            navigate('/LogIn')
        } else {
        setLends(response.data.lends)
        setNoOfPages(Math.ceil(response.data.count / 8))
        }
    }

    useEffect(() => { loadLends() }, [page,filterTime])

    return (
        <div>
            <ApplicationMenuBar />
            <Box className="filters" sx={{ display: "flex", width: '100%',marginTop:"8px" }} >
            <TimeFilter filterTime={filterTime} setFilterTime={setFilterTime} setPage={setPage}/>
            </Box>
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