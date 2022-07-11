import { useParams } from "react-router-dom";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { useEffect, useState } from "react";
import { Grid, Typography, Box } from "@mui/material";
import ComicBookDetailCard from "../Cards/ComicBookDetailCard";
import NewLend from "../Cards/CreateLendComponent";
import { getComicBook } from "../../services/ComicBooksService";
import LendTimesDialog from "../Cards/Dialog/LendTimesDialog";
import AddReviewDialog from "../Cards/Dialog/AddReviewDialog";
import SeeReviewsDialog from "../Cards/Dialog/SeeReviewsDialog";
import Tab from '@mui/material/Tab';
import TabContext from '@mui/lab/TabContext';
import TabList from '@mui/lab/TabList';
import TabPanel from '@mui/lab/TabPanel';
import FavoritesComponent from "../Cards/Favorites";
function ComicBookPage() {

    let { id } = useParams()
    const [refresh, setRefresh] = useState(0)

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

    const [value, setValue] = useState('1');

    const handleChange = (event, newValue) => {
        setValue(newValue);
    };

    useEffect(() => { loadComic() }, [])



    return (
        <>
            <ApplicationMenuBar />
            <main>
                <Grid container margin={'1%'} width="99%" columnSpacing={1}>
                    <Grid item xs={12} md={6}  >
                        <ComicBookDetailCard comicBook={comicBook} refresh={refresh} />
                    </Grid>
                    <Grid item xs={12} md={6} sx={{ display: "flex", flexDirection: "column" }} >
                        <Box style={{
                            display: 'flex',
                            alignItems: 'center',
                            flexWrap: 'wrap',
                        }}>
                            <FavoritesComponent></FavoritesComponent>
                            <Typography style={{ fontWeight: 600 }}>   Add To Favorites</Typography></Box>
                       

                        <TabContext value={value}>
                            <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
                                <TabList onChange={handleChange} aria-label="lab API tabs example">
                                    <Tab label="Borrow" value="1" />
                                    <Tab label="See Other Lends" value="2" />
                                    <Tab label="See Reviews" value="3" />
                                    <Tab label="Add Review" value="4" />
                                </TabList>
                            </Box>
                            <TabPanel value="1"><NewLend comicBook={comicBook} /></TabPanel>
                            <TabPanel value="2"><LendTimesDialog id={id}></LendTimesDialog></TabPanel>
                            <TabPanel value="3"><SeeReviewsDialog comicId={id} /></TabPanel>
                            <TabPanel value="4"><AddReviewDialog comicId={id} setValue={setValue} setRefresh={setRefresh} refresh={refresh} /></TabPanel>
                        </TabContext>

                    </Grid>
                </Grid>

            </main>

        </>

    )

}
export default ComicBookPage;