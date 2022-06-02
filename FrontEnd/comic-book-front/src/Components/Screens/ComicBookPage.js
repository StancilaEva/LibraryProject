import { useParams } from "react-router-dom";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useEffect, useState } from "react";
import { Grid } from "@mui/material";
import ComicBookDetailCard from "../Cards/ComicBookDetailCard";
import NewLend from "../Cards/CreateLendComponent";
import { getComicBook } from "../../services/ComicBooksService";
import LendTimesDialog from "../Cards/Dialog/LendTimesDialog";
function ComicBookPage() {

    let { id } = useParams()

    const [comicBook, setComicBook] = useState({
        id: 0,
        title: '',
        cover: '',
        genre: '',
        publisher: '',
        issueNumber: 0
    });

    const loadComic = async () => {
        const response = await getComicBook(id)
        setComicBook(response)
    }


    useEffect(() => { loadComic() }, [])



    return (
        <>
            <ApplicationMenuBar />
            <main>
                <Grid container margin={'1%'} width="99%">
                    <Grid item xs={12} md={6}  >
                        <ComicBookDetailCard comicBook={comicBook} />
                        <LendTimesDialog id={id} sx={{margin:'8px'}}></LendTimesDialog>
                    </Grid>
                    <Grid item xs={12} md={6} sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }} >
                        <NewLend comicBook={comicBook} />
                    </Grid>
                </Grid>

            </main>

        </>

    )

}
export default ComicBookPage;