﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows;

namespace NetworkView.NetworkUI
{
    /// <summary>
    /// Base class for connection dragging event args.
    /// </summary>
    public class ConnectionDragEventArgs : RoutedEventArgs
    {
        #region Private Data Members

        /// <summary>
        /// The NodeItem or it's DataContext (when non-NULL).
        /// </summary>
        private readonly object _node;

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        private readonly object _draggedOutConnector;

        /// <summary>
        /// The connector that will be dragged out.
        /// </summary>
        protected object Connection;

        #endregion Private Data Members

        /// <summary>
        /// The NodeItem or it's DataContext (when non-NULL).
        /// </summary>
        public object Node => _node;

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        public object ConnectorDraggedOut => _draggedOutConnector;

        #region Private Methods

        protected ConnectionDragEventArgs(RoutedEvent routedEvent, object source, object node, object connection, object connector) :
            base(routedEvent, source)
        {
            this._node = node;
            _draggedOutConnector = connector;
            this.Connection = connection;
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Arguments for event raised when the user starts to drag a connection out from a node.
    /// </summary>
    public class ConnectionDragStartedEventArgs : ConnectionDragEventArgs
    {
        /// <summary>
        /// The connection that will be dragged out.
        /// </summary>
        public object Connection
        {
            get
            {
                return base.Connection;
            }
            set
            {
                base.Connection = value;
            }
        }

        #region Private Methods

        internal ConnectionDragStartedEventArgs(RoutedEvent routedEvent, object source, object node, object connector) :
            base(routedEvent, source, node, null, connector)
        {
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Defines the event handler for the ConnectionDragStarted event.
    /// </summary>
    public delegate void ConnectionDragStartedEventHandler(object sender, ConnectionDragStartedEventArgs e);

    /// <summary>
    /// Arguments for event raised while user is dragging a node in the network.
    /// </summary>
    public class QueryConnectionFeedbackEventArgs : ConnectionDragEventArgs
    {
        #region Private Data Members

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        private readonly object _draggedOverConnector;

        /// <summary>
        /// Set to 'true' / 'false' to indicate that the connection from the dragged out connection to the dragged over connector is valid.
        /// </summary>
        private bool _connectionOk = true;

        /// <summary>
        /// The indicator to display.
        /// </summary>
        private object _feedbackIndicator;

        #endregion Private Data Members

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        public object DraggedOverConnector => _draggedOverConnector;

        /// <summary>
        /// The connection that will be dragged out.
        /// </summary>
        public object Connection => base.Connection;

        /// <summary>
        /// Set to 'true' / 'false' to indicate that the connection from the dragged out connection to the dragged over connector is valid.
        /// </summary>
        public bool ConnectionOk
        {
            get
            {
                return _connectionOk;
            }
            set
            {
                _connectionOk = value;
            }
        }

        /// <summary>
        /// The indicator to display.
        /// </summary>
        public object FeedbackIndicator
        {
            get
            {
                return _feedbackIndicator;
            }
            set
            {
                _feedbackIndicator = value;
            }
        }

        #region Private Methods

        internal QueryConnectionFeedbackEventArgs(RoutedEvent routedEvent, object source, 
            object node, object connection, object connector, object draggedOverConnector) :
            base(routedEvent, source, node, connection, connector)
        {
            this._draggedOverConnector = draggedOverConnector;
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Defines the event handler for the QueryConnectionFeedback event.
    /// </summary>
    public delegate void QueryConnectionFeedbackEventHandler(object sender, QueryConnectionFeedbackEventArgs e);

    /// <summary>
    /// Arguments for event raised while user is dragging a node in the network.
    /// </summary>
    public class ConnectionDraggingEventArgs : ConnectionDragEventArgs
    {
        /// <summary>
        /// The connection being dragged out.
        /// </summary>
        public object Connection => base.Connection;

        #region Private Methods

        internal ConnectionDraggingEventArgs(RoutedEvent routedEvent, object source,
                object node, object connection, object connector) :
            base(routedEvent, source, node, connection, connector)
        {
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Defines the event handler for the ConnectionDragging event.
    /// </summary>
    public delegate void ConnectionDraggingEventHandler(object sender, ConnectionDraggingEventArgs e);

    /// <summary>
    /// Arguments for event raised when the user has completed dragging a connector.
    /// </summary>
    public class ConnectionDragCompletedEventArgs : ConnectionDragEventArgs
    {
        #region Private Data Members

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        private readonly object _connectorDraggedOver;

        #endregion Private Data Members

        /// <summary>
        /// The ConnectorItem or it's DataContext (when non-NULL).
        /// </summary>
        public object ConnectorDraggedOver => _connectorDraggedOver;

        /// <summary>
        /// The connection that will be dragged out.
        /// </summary>
        public object Connection => base.Connection;

        #region Private Methods

        internal ConnectionDragCompletedEventArgs(RoutedEvent routedEvent, object source, object node, object connection, object connector, object connectorDraggedOver) :
            base(routedEvent, source, node, connection, connector)
        {
            this._connectorDraggedOver = connectorDraggedOver;
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Defines the event handler for the ConnectionDragCompleted event.
    /// </summary>
    public delegate void ConnectionDragCompletedEventHandler(object sender, ConnectionDragCompletedEventArgs e);
}
