import { useEffect, useState } from "react";
import ApplicationMenuBar from "../Cards/ApplicationMenuBar";
import { Button, Card, CardMedia, CssBaseline, Typography } from "@mui/material";
import { Grid } from "@mui/material";
import { CardContent } from "@mui/material";
import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from "@mui/x-date-pickers";
import { TextField } from "@mui/material";
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { useParams } from "react-router-dom";
import { getLendById } from "../../services/LendService";
import { extendLend } from "../../services/LendService";
import { Collapse } from "@mui/material";
import SuccessfulLend from "../Cards/Toasts/SuccesfulLend";
import UnsuccessfulLend from "../Cards/Toasts/UnsuccessfulLend";
import ExtendLend from "../Cards/ExtendLend";

function LendPage() {
    const { id } = useParams()
  
    const [lend, setLend] = useState({
        lendId: 0,
        comicBookId: 0,
        comicBookTitle: '',
        comicBookCover: '',
        clientId: 0,
        email: '',
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        extended: false
    })
    const [updated,setUpdated] = useState(false)

    const LoadLend = async () => {
        const result = await getLendById(id)
        setLend(result);
    }

    useEffect(() => { LoadLend() }, [updated])

    const parseDate = () =>{
        let startDate  = new Date(lend.startDate)
        let endDate  = new Date(lend.endDate)
        return( `${startDate.getDate()}/${startDate.getMonth()+1}/${startDate.getFullYear()} TO ${endDate.getDate()}/${endDate.getMonth()+1}/${endDate.getFullYear()}`)
      }
  
    function renderExtension() {
        if (lend.extended == true) {
            return (<Typography>Only one extension per lend</Typography>)
        }
        else {
            return (<ExtendLend id={id} setUpdated={setUpdated}/>)
        }
    }

    return (
        <>
            <ApplicationMenuBar />
            <main>
                <Grid container margin={'1%'} width="99%">
                    <Grid item xs={12} md={6}>
                        <Card sx={{ objectFit: 'contain', height: '85vh' }} >
                            <CardMedia
                                component="img"
                                image={require(`../../${lend.comicBookCover}`)}
                                sx={{ objectFit: 'contain', height: '65vh' }} />
                            <CardContent>
                                <Container>
                                    <Box sx={{ display: 'flex' }}>
                                        <Typography gutterBottom variant="h5" component="div" flex='75%'>
                                            {lend.comicBookTitle}
                                        </Typography>
                                    </Box>
                                    <Typography gutterBottom variant="h6" component="div" color="text.secondary">
                                        {parseDate()}
                                    </Typography>
                                </Container>
                            </CardContent>
                        </Card>
                    </Grid>
                    <Grid item xs={12} md={6} sx={{ display: "flex", justifyContent: "center", alignItems: "center" }} >
                        {renderExtension()}
                    </Grid>
                </Grid>
            </main>
        </>
    )
}
export default LendPage;