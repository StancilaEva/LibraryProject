import { Alert } from "@mui/material";
import { IconButton } from "@mui/material";
import CloseIcon from '@mui/icons-material/Close';
import { Collapse } from "@mui/material";
function SuccessfulLend(props) {
    const {setShowMessage} = props
    return (<Alert
            severity="success"
            action={
                <IconButton
                    aria-label="close"
                    color="inherit"
                    size="small"
                    onClick={() => {
                        setShowMessage(false);
                    }}
                >
                    <CloseIcon fontSize="inherit" />
                </IconButton>
            }
            sx={{ mb: 2, width: '50vh' }}
        >
            Lend Was Successful!
        </Alert>)
}
export default SuccessfulLend;