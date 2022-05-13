import AppBar from '@mui/material/AppBar';
import { Box } from '@mui/material';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import MenuItem from '@mui/material/MenuItem';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Menu from '@mui/material/Menu';
import HomeIcon from '@mui/icons-material/Home';
import SearchComic from './FilterInputs/SearchComic';

function ApplicationMenuBar(){


    const [anchorEl, setAnchorEl] = useState(null);
    const open = Boolean(anchorEl);

    const navigate = useNavigate();

    //adauga meniul definit la menu icon
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };
   
    const onMyLendsClick = () =>{
        navigate(`/Client/1/Lends`)
    }

    const onMyAddressClick = () =>{
        navigate(`/Client/1/Address`)
    }

    const goToHome = () =>{
        navigate(`/`)
    }

    return (
        <div>
            <Box sx={{ flexGrow: 1 }}>
            <AppBar position='static'>
                    <Toolbar>
                        <IconButton
                            size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{ mr: 2 }}
                            onClick={handleClick}>
                            <MenuIcon />
                        </IconButton>
                        <HomeIcon
                          onClick={goToHome} />
                        <SearchComic sx={{width:'100px',position:'absolute',right:0}}/>
                    </Toolbar>
                </AppBar>
            </Box>
            <Menu
                id="basic-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                MenuListProps={{
                    'aria-labelledby': 'basic-button',
                }}
            >
                <MenuItem onClick={onMyLendsClick}>My Lends</MenuItem>
                <MenuItem onClick={onMyAddressClick}>Address</MenuItem>
            </Menu>
        </div>
    )
}

export default ApplicationMenuBar;