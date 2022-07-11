import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useState, useEffect } from "react"
import { TextField, Box } from "@mui/material"
import { Grid } from "@mui/material";
import ComicBookGridCard from "../Cards/GridCards/ComicBookGridCard"
import { Pagination } from "@mui/material"
import { getClientFavorites } from "../../services/FavoriteService";
import { useNavigate } from "react-router";

const FavoritesPage = () =>{
    const [comics, setComicBooks] = useState([])
    const [page, setPage] = useState(1)
    const [noOfPAges, setNoOfPages] = useState(0)
    const navigate = useNavigate()
    
    const loadComics = async () => {
        const result = await getClientFavorites(page)
        if(result.statusCode==200){
        setComicBooks(result.result.comicBooks)
        setNoOfPages(Math.ceil(result.result.recordCount / 8))
        }
        else{
            localStorage.clear()
            navigate('/LogIn')
        }
    };

    useEffect(()=>{loadComics()},[page])
    return (
        <div>
        <ApplicationMenuBar />
        <main>
            <Grid container spacing={3} marginLeft={"0.05%"} marginTop="0.05%" width="99%">
                {
                    comics.map((comic, index) => <Grid item xs={12} sm={6} md={3} key={index}><ComicBookGridCard key={index} comicBook={comic} ></ComicBookGridCard></Grid>)
                }
            </Grid>
            <Box display={"flex"} justifyContent={"center"}>
                <Pagination count={noOfPAges} page={page} onChange={(evt, value) => { setPage(value) }} sx={{marginTop:"16px",marginBottom:"16px"}} />
            </Box>
        </main>
    </div>
    )
}
export default FavoritesPage;