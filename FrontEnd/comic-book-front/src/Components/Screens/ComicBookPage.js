import { useParams } from "react-router-dom";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useEffect, useState } from "react";
import { Button, Card, CardMedia, CssBaseline, Typography } from "@mui/material";
import { Grid } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import Alert from '@mui/material/Alert';
import IconButton from '@mui/material/IconButton';
import Collapse from '@mui/material/Collapse';
import CloseIcon from '@mui/icons-material/Close';
import ComicBookDetailCard from "../Cards/ComicBookDetailCard";
import NewLend from "../Cards/NewLend";
import api from "../../api/posts"

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
        const response = await api.get(`/ComicBooks/${id}`)
        if (response.status == 200) {
            var result = await response.data
            setComicBook(result)
        }
        else {
            alert(response.status)
        }
    }


    useEffect(() => { loadComic() }, [])

    

    return (
        <>
            <ApplicationMenuBar />
            <main>
                <Grid container margin={'1%'} width="99%">
                    <Grid item xs={12} md={6}  >
                        <ComicBookDetailCard comicBook={comicBook}/>
                    </Grid>
                    <Grid item xs={12} md={6} sx={{ display: "flex", flexDirection: "column", justifyContent: "center", alignItems: "center" }} >
                            <NewLend comicBook={comicBook}/>
                    </Grid>
                </Grid>

            </main>

        </>

    )

}
export default ComicBookPage;