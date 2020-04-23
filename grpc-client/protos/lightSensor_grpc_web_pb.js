/**
 * @fileoverview gRPC-Web generated client stub for light_sensor_message
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!



const grpc = {};
grpc.web = require('grpc-web');

const proto = {};
proto.light_sensor_message = require('./lightSensor_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.light_sensor_message.LigthSensorClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?Object} options
 * @constructor
 * @struct
 * @final
 */
proto.light_sensor_message.LigthSensorPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options['format'] = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.light_sensor_message.LightSensorMessagesRequest,
 *   !proto.light_sensor_message.LightSensorMessage>}
 */
const methodDescriptor_LigthSensor_GetLightSensorStream = new grpc.web.MethodDescriptor(
  '/light_sensor_message.LigthSensor/GetLightSensorStream',
  grpc.web.MethodType.SERVER_STREAMING,
  proto.light_sensor_message.LightSensorMessagesRequest,
  proto.light_sensor_message.LightSensorMessage,
  /**
   * @param {!proto.light_sensor_message.LightSensorMessagesRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.light_sensor_message.LightSensorMessage.deserializeBinary
);


/**
 * @const
 * @type {!grpc.web.AbstractClientBase.MethodInfo<
 *   !proto.light_sensor_message.LightSensorMessagesRequest,
 *   !proto.light_sensor_message.LightSensorMessage>}
 */
const methodInfo_LigthSensor_GetLightSensorStream = new grpc.web.AbstractClientBase.MethodInfo(
  proto.light_sensor_message.LightSensorMessage,
  /**
   * @param {!proto.light_sensor_message.LightSensorMessagesRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.light_sensor_message.LightSensorMessage.deserializeBinary
);


/**
 * @param {!proto.light_sensor_message.LightSensorMessagesRequest} request The request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.light_sensor_message.LightSensorMessage>}
 *     The XHR Node Readable Stream
 */
proto.light_sensor_message.LigthSensorClient.prototype.getLightSensorStream =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/light_sensor_message.LigthSensor/GetLightSensorStream',
      request,
      metadata || {},
      methodDescriptor_LigthSensor_GetLightSensorStream);
};


/**
 * @param {!proto.light_sensor_message.LightSensorMessagesRequest} request The request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @return {!grpc.web.ClientReadableStream<!proto.light_sensor_message.LightSensorMessage>}
 *     The XHR Node Readable Stream
 */
proto.light_sensor_message.LigthSensorPromiseClient.prototype.getLightSensorStream =
    function(request, metadata) {
  return this.client_.serverStreaming(this.hostname_ +
      '/light_sensor_message.LigthSensor/GetLightSensorStream',
      request,
      metadata || {},
      methodDescriptor_LigthSensor_GetLightSensorStream);
};


module.exports = proto.light_sensor_message;

