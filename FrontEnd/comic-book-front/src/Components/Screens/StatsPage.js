import { Grid, Typography,Divider,Box } from "@mui/material";
import { useEffect, useState } from "react";
import ComicBookGridCard from "../Cards/GridCards/ComicBookGridCard";
import { GetMostBorrowedBooks,GetMostReadGenres,GetMostReadPublishers } from "../../services/StatsService";
import { Card } from "@mui/material";
import { GetUserWithMostComics } from "../../services/StatsService";
import StarIcon from '@mui/icons-material/Star';
import FavoriteIcon from '@mui/icons-material/Favorite';

import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import BarChart from "../Cards/Charts/GenresBarChart";
import { PieChart } from "@mui/icons-material";
import PublishersPieChart from "../Cards/Charts/PublishersPieChart";

const StatsPage = () =>{

    const [mostBorrowed,setMostBorrowed] = useState([])
    const [userStats,setUser] = useState([])

    const loadGetMostBorrowed = async () =>
    {
        const response = await GetMostBorrowedBooks()
        setMostBorrowed(response)
    }
    
    const loadUserWithMostComics = async () =>{
        const response = await GetUserWithMostComics()
        setUser(response)
    }

    useEffect(() => { 
        loadGetMostBorrowed();
        loadUserWithMostComics();
     }, []);

    return(
    <>
    <ApplicationMenuBar/>
    <main>
        <Grid container spacing={3} padding={"16px"}>
            <Grid item xs={12} sm={12} md={12} marginTop={"16px"}>
                <Typography variant="h6" sx={{margin:'4px'}}>Top Comics This Month</Typography>
            </Grid>
            {
                mostBorrowed.map((comic, index) => 
                <Grid item xs={12} sm={6} md={4} key={index} sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                    {index===0?
                    <Typography variant="h6"><FavoriteIcon sx={{marginLeft:'4px',color:"#FFD32D"}}/> has been borrowed {comic.count} times this month:</Typography>:
                    <Typography variant="h6">has been borrowed {comic.count} time{comic.count===1?'':'s'} this month:</Typography>
                    }
                    <ComicBookGridCard key={index} 
                    comicBook={{
                        id:comic.id,
                        title:comic.title,
                        cover:comic.cover,}}
                    ></ComicBookGridCard>
                    </Grid>)
            }
            <Grid item xs={12}sm={12} md={12}/>
            <Grid item xs={12} sm={12} md={6} marginTop={"32px"} >
                <Card>
                <Typography variant="h6" sx={{margin:'8px'}}>Top Genres</Typography>
                <BarChart></BarChart>
                </Card>
            </Grid>
            <Grid item xs={12} sm={12} md={6} marginTop={"32px"}  >
            <Card padding={"4px"}  sx={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                <Typography variant="h6" sx={{margin:'8px'}} >Top Publishers</Typography>
                <PublishersPieChart/>
            </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={6} marginTop={"32px"}>
            <Card>
                <Typography variant="h6" sx={{margin:'8px'}}>Top Users</Typography>
                <Divider />
                <Box >
                {
                    userStats.map((user,index)=>
                    <Typography variant="h6" sx={{margin:'8px'}} key={index}><StarIcon sx={{color:"#FFD32D"}}/>{`${user.username} with ${user.count} comics`}</Typography>
                    )
                }
                </Box>
            </Card>
            </Grid>
        </Grid>
    </main>
    </>
    )
}
export default StatsPage;