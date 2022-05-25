import { useState, useEffect } from "react"
import ApplicationMenuBar from "../Cards/ApplicationMenuBar"
import { TextField, Box } from "@mui/material"
import { Grid } from "@mui/material";
import ComicBookGridCard from "../Cards/GridCards/ComicBookGridCard"
import { Pagination } from "@mui/material"
import { getComicBooks } from "../../services/ComicBooksService";
import SortFilter from "../Cards/FilterInputs/SortFilter";
import PublisherFilter from "../Cards/FilterInputs/PublisherFilter";
import GenreFilter from "../Cards/FilterInputs/GenreFilter";
import { useContext } from "react";
import { UserContext } from "../../Context/userContext";

function AltHomePage() {
    const sortOptions = [
        { label: 'Title Asc', value: 'asc' },
        { label: 'Title Desc', value: 'desc' }
    ]

    const [comics, setComicBooks] = useState([])
    const [page, setPage] = useState(1)

    const [sortOrder, setSortOrder] = useState(sortOptions[0])
    const [noOfPAges, setNoOfPages] = useState(0)

    const [filterPublisher, setFilterPublisher] = useState("");
    const [filterGenre, setFilterGenre] = useState("");


    const loadComics = async () => {
          const result = await getComicBooks(page,sortOrder,filterPublisher,filterGenre)
          setComicBooks(result.comicBooks)
          setNoOfPages(Math.ceil(result.recordCount / 8))
    };

    useEffect(() => { loadComics() }, [page, sortOrder, filterPublisher, filterGenre]);


    return (
        <div>
            <ApplicationMenuBar />
            <main>
                <Box className="filters" sx={{ display: "flex", width: '100%' }}>
                <SortFilter sortOrder={sortOrder} setSortOrder={setSortOrder} sortOptions={sortOptions}/>
                <PublisherFilter filterPublisher={filterPublisher} setFilterPublisher={setFilterPublisher} setPage={setPage}/>
                <GenreFilter filterGenre={filterGenre} setFilterGenre={setFilterGenre} setPage={setPage}/>
                </Box>
                <Grid container spacing={3} marginLeft={"0.05%"} marginTop="0.05%" width="99%">
                    {
                        comics.map((comic, index) => <Grid item xs={12} sm={6} md={3} key={index}><ComicBookGridCard key={index} comicBook={comic} ></ComicBookGridCard></Grid>)
                    }
                </Grid>
                <Box display={"flex"} justifyContent={"center"}>
                    <Pagination count={noOfPAges} page={page} onChange={(evt, value) => { setPage(value) }} />
                </Box>
            </main>
        </div>
    )
}
export default AltHomePage;