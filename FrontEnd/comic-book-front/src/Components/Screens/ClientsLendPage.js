import { useEffect, useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useParams } from "react-router-dom";
import LendCard from "../Cards/GridCards/LendCard";
import { Grid } from "@mui/material";
import api from "../../api/posts"
import { getAllClientLends } from "../../services/LendService";
import Pagination from "@mui/material/Pagination";
function ClientLends() {
    const [lends, setLends] = useState([])
    const [lendsToShow,setLendsToShow] = useState([])
    const [currentPage,setCurrentPage] = useState()
    const loadLends = async () => {
        const response = await getAllClientLends()
        setLends(response)
    }

    useEffect(() => { loadLends() }, [])

    return (
        <div>
            <ApplicationMenuBar />
            <Grid container spacing={3} marginLeft={"0.05%"} marginTop="0.05%" width="99%">
                {
                    lends.map((lend, index) => <Grid item xs={12} sm={6} md={3} key={index}><LendCard key={index} lend={lend}></LendCard></Grid>)
                }
            </Grid>
            <Pagination/>
        </div>)
}
export default ClientLends;