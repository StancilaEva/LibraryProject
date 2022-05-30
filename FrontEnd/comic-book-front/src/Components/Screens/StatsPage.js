import { Grid, Typography,Divider,Box } from "@mui/material";
import { useEffect, useState } from "react";
import ComicBookGridCard from "../Cards/GridCards/ComicBookGridCard";
import { GetMostBorrowedBooks,GetMostReadGenres,GetMostReadPublishers } from "../../services/StatsService";
import { Card } from "@mui/material";
import { GetUserWithMostComics } from "../../services/StatsService";
import StarIcon from '@mui/icons-material/Star';
import FavoriteIcon from '@mui/icons-material/Favorite';

import ApplicationMenuBar from "../Cards/ApplicationMenuBar";

const StatsPage = () =>{

    const [mostBorrowed,setMostBorrowed] = useState([])
    const [mostReadGenres,setMostReadGenres] = useState([])
    const [mostReadPublishers,setMostReadPublishers] = useState([])
    const [userStats,setUser] = useState({
        username:'',
        count:0
    })

    const loadGetMostBorrowed = async () =>
    {
        const response = await GetMostBorrowedBooks()
        setMostBorrowed(response)
    }

    const loadMostReadGenres = async () =>{
        const response = await GetMostReadGenres()
        setMostReadGenres(response)
    }

    const loadMostReadPublishers = async () =>{
        const response = await GetMostReadPublishers()
        setMostReadPublishers(response)
    }
    
    const loadUserWithMostComics = async () =>{
        const response = await GetUserWithMostComics()
        setUser(response)
    }

    useEffect(() => { 
        loadGetMostBorrowed();
        loadMostReadGenres();
        loadMostReadPublishers();
        loadUserWithMostComics();
     }, []);

    return(
    <>
    <ApplicationMenuBar/>
    <main>
        <Grid container spacing={3} padding={"16px"}>
            <Grid item xs={12} sm={12} md={12} marginTop={"16px"}>
                <Typography variant="h6" sx={{margin:'4px'}}>Most Borrowed Comics This Month</Typography>
            </Grid>
            {
                mostBorrowed.map((comic, index) => 
                <Grid item xs={12} sm={6} md={4} key={index} sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center"}}>
                    {index===0?
                    <Typography variant="h6"><FavoriteIcon sx={{marginLeft:'4px'}} color="primary"/> has been borrowed {comic.count} times this month:</Typography>:
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
                <Typography variant="h6" sx={{margin:'8px'}}>Most Read Genres</Typography>
                <Divider />
                {
                    mostReadGenres.map((genres,index)=>
                    <Typography key={index}>{`${index + 1}. ${genres.count} ${genres.genre} comics`}</Typography>)
                }
                </Card>
            </Grid>
            <Grid item xs={12} sm={12} md={6} marginTop={"32px"} >
            <Card padding={"4px"}>
                <Typography variant="h6" sx={{margin:'8px'}}>Most Read Publishers</Typography>
                <Divider />
                {
                    mostReadPublishers.map((genres,index)=>
                    <Typography key={index}>{`${index + 1}. ${genres.count} comics from ${genres.publishers}`}</Typography>)
                }
            </Card>
            </Grid>
            <Grid item xs={12} sm={6} md={6} marginTop={"32px"}>
            <Card>
                <Typography variant="h6" sx={{margin:'8px'}}>User With Most Borrowed Comics</Typography>
                <Divider />
                <Box sx={{display:'flex'}} >
                    {userStats?<Typography variant="h6" sx={{margin:'8px'}}><StarIcon color="secondary"/>{`${userStats.username} with ${userStats.count} comics`}</Typography>:
                    <Typography variant="h6" sx={{margin:'8px'}}>No Lends</Typography>}
                </Box>
            </Card>
            </Grid>
        </Grid>
    </main>
    </>
    )
}
export default StatsPage;