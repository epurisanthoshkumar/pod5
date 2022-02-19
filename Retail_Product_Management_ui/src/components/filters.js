import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
//import { connect } from 'react-redux';

const useStyles = makeStyles(theme => ({
  button: {
    margin: theme.spacing(1)
  },
  input: {
    display: 'none'
  }
}));

function filter(props) {
    const classes = useStyles();
    return (
      <div>
        <Button
          onClick={props.clearFilters}
          variant="contained"
          className={classes.button}
        >
          Clear Filters
        </Button>
      </div>
    );
  }
  export default connect(
    null,
    mapDispatchToProps
  )(ClearFiltersButton);